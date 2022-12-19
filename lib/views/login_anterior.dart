// import 'package:flutter/material.dart';
// import 'package:font_awesome_flutter/font_awesome_flutter.dart';
// import 'signup.dart';

// void main() {
//   runApp(const Login());
// }

// class Login extends StatelessWidget {
//   const Login({super.key});

//   // This widget is the root of your application.
//   @override
//   Widget build(BuildContext context) {
//     return MaterialApp(
//       title: 'Flutter Demo',
//       theme: ThemeData(
//         // This is the theme of your application.
//         //
//         // Try running your application with "flutter run". You'll see the
//         // application has a blue toolbar. Then, without quitting the app, try
//         // changing the primarySwatch below to Colors.green and then invoke
//         // "hot reload" (press "r" in the console where you ran "flutter run",
//         // or simply save your changes to "hot reload" in a Flutter IDE).
//         // Notice that the counter didn't reset back to zero; the application
//         // is not restarted.
//         primarySwatch: Colors.blue,
//       ),
//       home: const MyHomePage(title: 'Flutter Demo Home Page'),
//     );
//   }
// }

// class MyHomePage extends StatefulWidget {
//   const MyHomePage({super.key, required this.title});

//   // This widget is the home page of your application. It is stateful, meaning
//   // that it has a State object (defined below) that contains fields that affect
//   // how it looks.

//   // This class is the configuration for the state. It holds the values (in this
//   // case the title) provided by the parent (in this case the App widget) and
//   // used by the build method of the State. Fields in a Widget subclass are
//   // always marked "final".

//   final String title;

//   @override
//   State<MyHomePage> createState() => _MyHomePageState();
// }

// class _MyHomePageState extends State<MyHomePage> {
//   int _counter = 0;

//   void _incrementCounter() {
//     setState(() {
//       // This call to setState tells the Flutter framework that something has
//       // changed in this State, which causes it to rerun the build method below
//       // so that the display can reflect the updated values. If we changed
//       // _counter without calling setState(), then the build method would not be
//       // called again, and so nothing would appear to happen.
//       _counter++;
//     });
//   }

//   @override
//   Widget build(BuildContext context) {
//     // This method is rerun every time setState is called, for instance as done
//     // by the _incrementCounter method above.
//     //
//     // The Flutter framework has been optimized to make rerunning build methods
//     // fast, so that you can just rebuild anything that needs updating rather
//     // than having to individually change instances of widgets.
//     return Scaffold(
//       // safe area

//       body: SafeArea(
//         child: Padding(
//           padding: const EdgeInsets.all(24),
//           child: Column(
//             mainAxisSize: MainAxisSize.max,
//             mainAxisAlignment: MainAxisAlignment.start,
//             crossAxisAlignment: CrossAxisAlignment.center,
//             children: [
//               Row(
//                 mainAxisSize: MainAxisSize.max,
//                 mainAxisAlignment: MainAxisAlignment.start,
//                 crossAxisAlignment: CrossAxisAlignment.center,
//                 children: [
//                   ClipRRect(
//                     borderRadius: BorderRadius.circular(8),
//                     child: Image.network(
//                       'https://picsum.photos/250?image=9',
//                       width: 60,
//                       height: 60,
//                       fit: BoxFit.cover,
//                     ),
//                   ),
//                 ],
//               ),
//               //set a row as anoher children
//               Padding(
//                 padding: const EdgeInsets.only(top: 44),
//                 child: Row(
//                   mainAxisSize: MainAxisSize.max,
//                   mainAxisAlignment: MainAxisAlignment.start,
//                   crossAxisAlignment: CrossAxisAlignment.center,

//                   //box fit cover
//                   children: [
//                     Container(
//                       height: 50,
//                       child: Padding(
//                         padding: const EdgeInsets.only(right: 16),
//                         child: Text(
//                           'Sign In',
//                           style: TextStyle(
//                             fontSize: 24,
//                             fontWeight: FontWeight.w600,
//                             fontFamily: 'Popins',
//                             color: Color(0xff000000),
//                           ),
//                         ),
//                       ),
//                     ),
//                     //navigate to another page when clicked
//                     GestureDetector(
//                       onTap: () {
//                         Navigator.push(
//                           context,
//                           MaterialPageRoute(
//                             builder: (context) => Signup(),
//                           ),
//                         );
//                       },
//                       child: Container(
//                         height: 50,
//                         child: Padding(
//                           padding: const EdgeInsets.only(right: 16, left: 16),
//                           child: Text(
//                             'Sign Up',
//                             style: TextStyle(
//                               fontSize: 24,
//                               fontWeight: FontWeight.w400,
//                               fontFamily: 'Popins',
//                               color: //color black with opacity
//                                   Color.fromRGBO(0, 0, 0, 0.5),
//                             ),
//                           ),
//                         ),
//                       ),
//                     )
//                   ],
//                 ),
//               ),
//               //set a row with text
//               Padding(
//                 padding: const EdgeInsets.only(top: 12),
//                 child: Row(
//                   mainAxisSize: MainAxisSize.max,
//                   mainAxisAlignment: MainAxisAlignment.start,
//                   crossAxisAlignment: CrossAxisAlignment.center,
//                   children: [
//                     Text(
//                       'Use the form below, to access your account.',
//                       style: TextStyle(
//                         fontSize: 14,
//                         fontWeight: FontWeight.w600,
//                         fontFamily: 'Popins',
//                         color: Color.fromRGBO(0, 0, 0, 0.5),
//                       ),
//                     ),
//                   ],
//                 ),
//               ),
//               //set a container with blur, padding top 24 and a child textfield with decoration and padding 2
//               Padding(
//                 padding: const EdgeInsets.only(top: 24),
//                 child: Container(
//                   width: double.infinity,
//                   decoration: BoxDecoration(
//                     color: Colors.white,
//                     borderRadius: BorderRadius.circular(12),
//                     boxShadow: [
//                       BoxShadow(
//                         color: Colors.black.withOpacity(0.1),
//                         spreadRadius: 1,
//                         blurRadius: 6,
//                         offset: const Offset(0, 2),
//                       ),
//                     ],
//                   ),
//                   child: Padding(
//                     padding: const EdgeInsets.all(2),
//                     child: TextField(
//                       decoration: InputDecoration(
//                         labelStyle: TextStyle(
//                           fontSize: 14,
//                           fontWeight: FontWeight.w600,
//                           fontFamily: 'Popins',
//                           color: Color.fromRGBO(0, 0, 0, 0.5),
//                         ),
//                         hintText: 'Your email adress',
//                         hintStyle: TextStyle(
//                           fontSize: 14,
//                           fontWeight: FontWeight.w600,
//                           fontFamily: 'Popins',
//                           color: Color.fromRGBO(0, 0, 0, 0.5),
//                         ),
//                         border: InputBorder.none,
//                         contentPadding: const EdgeInsets.only(
//                             left: 20, right: 20, top: 24, bottom: 24),
//                       ),
//                     ),
//                   ),
//                 ),
//               ),
//               Padding(
//                 padding: const EdgeInsets.only(top: 16),
//                 child: Container(
//                   width: double.infinity,
//                   decoration: BoxDecoration(
//                     color: Colors.white,
//                     borderRadius: BorderRadius.circular(12),
//                     boxShadow: [
//                       BoxShadow(
//                         color: Colors.black.withOpacity(0.1),
//                         spreadRadius: 1,
//                         blurRadius: 6,
//                         offset: const Offset(0, 2),
//                       ),
//                     ],
//                   ),
//                   child: Padding(
//                     padding: const EdgeInsets.all(2),
//                     child: TextField(
//                       obscureText: true,
//                       decoration: InputDecoration(
//                         hintText: 'Password',
//                         labelStyle: TextStyle(
//                           fontSize: 14,
//                           fontWeight: FontWeight.w600,
//                           fontFamily: 'Popins',
//                           color: Color.fromRGBO(0, 0, 0, 0.5),
//                         ),
//                         hintStyle: TextStyle(
//                           fontSize: 14,
//                           fontWeight: FontWeight.w600,
//                           fontFamily: 'Popins',
//                           color: Color.fromRGBO(0, 0, 0, 0.5),
//                         ),
//                         border: InputBorder.none,
//                         contentPadding: const EdgeInsets.only(
//                             left: 20, right: 20, top: 24, bottom: 24),
//                       ),
//                     ),
//                   ),
//                 ),
//               ),
//               Padding(
//                 padding: const EdgeInsets.only(top: 20),
//                 child: Row(
//                   mainAxisSize: MainAxisSize.max,
//                   mainAxisAlignment: MainAxisAlignment.spaceBetween,
//                   crossAxisAlignment: CrossAxisAlignment.center,
//                   children: [
//                     Padding(
//                       padding: const EdgeInsets.only(top: 16),
//                       child: Container(
//                         width: 165,
//                         height: 50,
//                         decoration: BoxDecoration(
//                           color: Color.fromARGB(214, 58, 44, 184),
//                           borderRadius: BorderRadius.circular(12),
//                           boxShadow: [
//                             BoxShadow(
//                               color: Colors.black.withOpacity(0.1),
//                               spreadRadius: 1,
//                               blurRadius: 6,
//                               offset: const Offset(0, 2),
//                             ),
//                           ],
//                         ),
//                         child: Center(
//                           child: Text(
//                             'Forgor Password?',
//                             style: TextStyle(
//                               fontSize: 16,
//                               fontWeight: FontWeight.w600,
//                               fontFamily: 'Popins',
//                               color: Colors.white,
//                             ),
//                           ),
//                         ),
//                       ),
//                     ),
//                     Padding(
//                       padding: const EdgeInsets.only(top: 16, left: 16),
//                       child: Container(
//                         width: 165,
//                         height: 50,
//                         decoration: BoxDecoration(
//                           color: //hex color #4B39EF
//                               Color.fromARGB(214, 58, 44, 184),
//                           borderRadius: BorderRadius.circular(12),
//                           boxShadow: [
//                             BoxShadow(
//                               color: Colors.black.withOpacity(0.1),
//                               spreadRadius: 1,
//                               blurRadius: 6,
//                               offset: const Offset(0, 2),
//                             ),
//                           ],
//                         ),
//                         child: Center(
//                           child: Text(
//                             'Login',
//                             style: TextStyle(
//                               fontSize: 18,
//                               fontWeight: FontWeight.w600,
//                               fontFamily: 'Popins',
//                               color: Colors.white,
//                             ),
//                           ),
//                         ),
//                       ),
//                     ),
//                   ],
//                 ),
//               ),
//               Column(
//                 //set button with text no color and google icon
//                 mainAxisSize: MainAxisSize.max,
//                 mainAxisAlignment: MainAxisAlignment.center,
//                 crossAxisAlignment: CrossAxisAlignment.center,
//                 children: [
//                   Padding(
//                     padding: const EdgeInsets.only(top: 24),
//                     child: Container(
//                       width: 300,
//                       height: 50,
//                       decoration: BoxDecoration(
//                         color: Colors.white,
//                         borderRadius: BorderRadius.circular(12),
//                       ),
//                       child: Center(
//                         child: TextButton.icon(
//                           onPressed: () {},
//                           icon: Icon(
//                             FontAwesomeIcons.google,
//                             color: Color.fromARGB(255, 0, 0, 0),
//                           ),
//                           label: Text(
//                             'Sign in with Google',
//                             style: TextStyle(
//                               fontSize: 14,
//                               fontWeight: FontWeight.w600,
//                               fontFamily: 'Popins',
//                               color: Color.fromRGBO(0, 0, 0, 0.5),
//                             ),
//                           ),
//                         ),
//                       ),
//                     ),
//                   ),
//                 ],
//               )
//             ],
//           ),
//         ),
//       ),
//     );
//   }
// }
