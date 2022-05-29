import React from "react";
import { Route, Routes } from "react-router-dom";
import SportFields from "./components/SportFields";
import Layout from "./components/Layout";
import { Home } from "./components/Home";
import ShowUsers from "./components/ShowUsers";
import AddUserForm from "./components/AddUserForm";
import NewAppointment from "./components/NewAppointment";
import SeeScheduler from "./components/SeeCalendar";
import AppointmentsCalendar from "./components/AppointmentCalendar";

function App() {
  return (
    <Layout>
      <Routes>
        <Route exact path="/"  element={<Home />} />
        <Route path="/sport-fields" exact element={<SportFields />} />
        <Route path="/show-all-users" exact element={<ShowUsers />} />
        <Route path="/add-user-form" exact element={<AddUserForm />} />
        <Route path="/select-date/:id" exact element={<NewAppointment />} />
        <Route path="/see-scheduler/:id" element={<SeeScheduler/>}/>
        <Route path="/appointments-calendar" element={<AppointmentsCalendar/>}/>
      </Routes>
    </Layout>
  );
}

export default App;