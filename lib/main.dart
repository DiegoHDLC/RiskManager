// set main function and use route to navigate to login as default, and import login.dart
import 'package:flutter/material.dart';
import 'views/login.dart';
import 'views/signup.dart';

void main() => runApp(MaterialApp(
      // home: Login(),

      initialRoute: '/login',
      routes: <String, WidgetBuilder>{
        '/login': (BuildContext context) => Login(),
        '/signup': (BuildContext context) => Signup(),
        '/': (context) => Login(),
        // '/home': (BuildContext context) => Home(),
      },
    ));
