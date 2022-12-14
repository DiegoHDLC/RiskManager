import psycopg2
from flask import Flask, jsonify, request

from flask_restful import Resource, Api

from flask_cors import CORS

#from flask_bcrypt import Bcrypt

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
        # encrypt password
        # bcrypt = Bcrypt(app)
        # data['contrasena'] = bcrypt.generate_password_hash(
        #     data['contrasena'].encode('utf-8'))

        print(data['contrasena'])
        # check if user exists
        cur.execute("SELECT * FROM usuarios WHERE correo = %s",
                    (data['correo'],))
        rows = cur.fetchall()
        if len(rows) > 0:
            return {"message": "User already exists."}, 400
        else:
            cur.execute("INSERT INTO usuarios (nombre, apellido, correo, contrasena) VALUES (%s, %s, %s, crypt(%s, gen_salt('bf')))",
                        (data['nombre'], data['apellido'], data['correo'], data['contrasena']))
            conn.commit()
            cur.close()
            return {"message": "User created successfully."}, 201


class Login(Resource):
    def post(self):
        data = request.get_json()
        cur = conn.cursor()
        # where correo = %s and contrasena = crypt(%s, contrasena)

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


if __name__ == '__main__':
    app.run(debug=True)
