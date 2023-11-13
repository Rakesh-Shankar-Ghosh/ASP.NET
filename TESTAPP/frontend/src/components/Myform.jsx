// 2nd
import React from "react";
import { Formik, Form, Field, ErrorMessage } from "formik";
import * as Yup from "yup";
import axios from "axios";
import { useNavigate } from "react-router-dom";
//import { useState } from "react";

//import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

const validationSchema = Yup.object().shape({
  FirstName: Yup.string().required("FirstName is required"),
    LastName: Yup.string()
    .typeError("LastName must be a String")
    .required("LastName is required"),
  EmailAddress: Yup.string().email()
    .typeError("Email be a ")
    .required("Email is required"),
  
});

const PostData = () => {
  const navigate = useNavigate();

  const handleSubmit = async (values) => {
    try {
      // Your API endpoint goes here
      console.table(values);
      const res = await axios.post(
        `${process.env.REACT_APP_API}/Student/AddStudent`,
        values
      );
      console.log(res);
      if (res.data.success) {
        navigate("/getdata");
      }
      // Handle success here, you can redirect to another page if needed
    } catch (error) {
      console.error("Error:", error);
      // Handle error here, display an error message or take appropriate action
    }
  };

  return (
    <>
      <div className="text-center">
        <Formik
          initialValues={{
            FirstName: "",
            LastName: "",
            EmailAddress: "",
           
          }}
          validationSchema={validationSchema}
          onSubmit={handleSubmit}
        >
          <Form>
            <div className="input-box">
              First Name:{" "}
              <Field type="text" name="FirstName" placeholder="Enter your name" />
              <ErrorMessage name="FirstName" component="div" color="red" />
            </div>
            <div className="input-box">
              Last Name:{" "}
              <Field type="text" name="LastName" placeholder="Enter your price" />
              <ErrorMessage name="LastName" component="div" />
            </div>

            <div className="input-box">
              Email :{" "}
              <Field type="email" name="EmailAddress" placeholder="Enter your price" />
              <ErrorMessage name="EmailAddress" component="div" />
            </div>
            

            <div className="input-box button">
              <button type="submit">Submit</button>
            </div>
          </Form>
        </Formik>
      </div>
    </>
  );
};

export default PostData;

// 1st
// import React from 'react';
// import { Formik, Form, Field, ErrorMessage } from 'formik';
// import * as Yup from 'yup';
// import axios from 'axios';
// import { useNavigate } from 'react-router-dom';

// const validationSchema = Yup.object().shape({
//   name: Yup.string().required('Name is required'),
//   price: Yup.number().typeError('Price must be a number').required('Price is required'),
//   quantity: Yup.number().typeError('Quantity must be a number').required('Quantity is required'),
// });

// const PostData = () => {
//   const navigate = useNavigate();

//   const handleSubmit = async (values) => {
//     try {
//       // Your API endpoint goes here
//       const res = await axios.post(`${process.env.REACT_APP_API}/create/product/`, values);
//       console.log(res);
//       if (res.data.success) {
//         navigate('/getdata');
//       }
//       // Handle success here, you can redirect to another page if needed
//     } catch (error) {
//       console.error('Error:', error);
//       // Handle error here, display an error message or take appropriate action
//     }
//   };

//   return (
//     <>
//       <div className="text-center">
//         <Formik
//           initialValues={{
//             name: '',
//             price: 0,
//             quantity: 0,
//           }}
//           validationSchema={validationSchema}
//           onSubmit={handleSubmit}
//         >
//           <Form>
//             <div className="input-box">
//               Name:{' '}
//               <Field type="text" name="name" placeholder="Enter your name" />
//               <ErrorMessage name="name" component="div" />
//             </div>
//             <div className="input-box">
//               Price:{' '}
//               <Field type="text" name="price" placeholder="Enter your price" />
//               <ErrorMessage name="price" component="div" />
//             </div>
//             <div className="input-box">
//               Quantity:{' '}
//               <Field type="number" name="quantity" placeholder="Enter your quantity" />
//               <ErrorMessage name="quantity" component="div" />
//             </div>
//             <div className="input-box button">
//               <button type="submit">Submit</button>
//             </div>
//           </Form>
//         </Formik>
//       </div>
//     </>
//   );
// };

// export default PostData;
