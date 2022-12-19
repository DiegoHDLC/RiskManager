import psycopg2
from flask import Flask, jsonify, request

from flask_restful import Resource, Api

from flask_cors import CORS

import smtplib

import secrets


# from flask_bcrypt import Bcrypt

app = Flask(__name__)
api = Api(app)
CORS(app)

conn = psycopg2.connect(
    host="35.193.211.16",
    database="risk-db",
    user="risk-db",
    password="risk123",
    port="5432"
)


class AddUser(Resource):
    def post(self):

        data = request.get_json()
        cur = conn.cursor()
        print(data['contrasena'])
        # check if user exists
        if checkUserExists(data['correo']):
            return {"message": "User already exists."}, 400
        else:
            cur.execute("INSERT INTO usuarios (nombre, apellido, correo, contrasena) VALUES (%s, %s, %s, crypt(%s, gen_salt('bf')))",
                        (data['nombre'], data['apellido'], data['correo'], data['contrasena']))
            conn.commit()
            cur.close()
            return {"message": "User created successfully."}, 201


# crear una funcion que verifique si el usuario existe
def checkUserExists(correo):
    cur = conn.cursor()
    cur.execute("SELECT * FROM usuarios WHERE correo = %s",
                (correo,))
    rows = cur.fetchall()
    print(rows)
    if len(rows) > 0:

        return True
    else:
        return False


def verificationCodeValidation(codigo, correo):
    cur = conn.cursor()
    cur.execute("SELECT * FROM verification_codes WHERE codigo = %s AND correo = %s AND expiracion > NOW()",
                (codigo, correo))
    rows = cur.fetchall()
    cur.close()
    if len(rows) > 0:
        # delete verification code
        cur = conn.cursor()
        cur.execute("DELETE FROM verification_codes WHERE codigo = %s AND correo = %s",
                    (codigo, correo))
        conn.commit()
        cur.close()
        return True
    else:
        return False


class UpdatePassword(Resource):
    def put(self):
        data = request.get_json()  # correo, new_contrasena
        cur = conn.cursor()
        # check if user exists
        if checkUserExists(data['correo']):
            if (verificationCodeValidation(data['codigo'], data['correo'])):
                cur.execute("UPDATE usuarios SET contrasena = crypt(%s, gen_salt('bf')) WHERE correo = %s",
                            (data['nueva_contrasena'], data['correo']))
                conn.commit()
                cur.close()
                return {"message": "Password updated successfully."}, 201
            else:
                return {"message": "Verification code is invalid."}, 400
        else:
            return {"message": "User does not exist."}, 400


# enviar correo para recuperar contraseña
class SendVerificationCodeByEmail(Resource):
    def post(self):
        user = "dhdlc30@gmail.com"
        password = "5722F86161825E22D1B8908D3E992116DC3D"
        server = smtplib.SMTP('smtp.elasticemail.com', 2525)
        server.login(user,
                     password)
        data = request.get_json()
        cur = conn.cursor()
        # check if user exists
        if checkUserExists(data['correo']):
            verification_code = secrets.token_hex(8)
            # get password decrypted
            cur.execute("INSERT INTO verification_codes (codigo, correo, expiracion) VALUES (%s, %s, NOW() + INTERVAL '1 hour')",
                        (verification_code, data['correo']))
            conn.commit()
            cur.close()
            # send email
            # email content
            to = data['correo']
            subject = "Codigo de verificacion"
            body = "Su codigo de verificacion es: " + \
                str(verification_code) + ". Este codigo expira en 1 hora." + \
                "Si no ha solicitado recuperar su contraseña, ignore este correo." + "Gracias."
            msg = f"Subject: {subject}\n\n{body}"
            msg = msg.encode('utf-8')
            server.sendmail(user, to, msg)
            server.quit()
            return {"message": "Email sent successfully."}, 201
        else:
            return {"message": "User does not exist."}, 400


class Login(Resource):
    def post(self):

        data = request.get_json()
        cur = conn.cursor()
        cur.execute("SELECT * FROM usuarios WHERE correo = %s and contrasena = crypt(%s, contrasena)",
                    (data['correo'], data['contrasena']))
        rows = cur.fetchall()
        cur.close()
        if len(rows) > 0:
            return {"message": "Login successful."}, 200
        else:
            return {"message": "Login failed."}, 401


api.add_resource(Login, '/login')
api.add_resource(AddUser, '/addUser')
api.add_resource(SendVerificationCodeByEmail,
                 '/sendVerificationCodeByEmail')
api.add_resource(UpdatePassword, '/updatePassword')


if __name__ == '__main__':
    app.run(debug=True)
