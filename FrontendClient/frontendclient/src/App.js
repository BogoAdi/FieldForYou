import React from "react";
import { Route, Routes } from "react-router-dom";
import SportFields from "./components/SportFields";
import Layout from "./components/Layout";
import { Home } from "./components/Home";
import ShowUsers from "./components/ShowUsers";

function App() {
  return (
    <Layout>
      <Routes>
        <Route exact path="/"  element={<Home />} />
        <Route path="/sport-fields" exact element={<SportFields />} />
        <Route path="/show-all-users" exact element={<ShowUsers />} />
      </Routes>
    </Layout>
  );
}

export default App;