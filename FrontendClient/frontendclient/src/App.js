import React from "react";
import { Route, Routes } from "react-router-dom";
import SportFields from "./components/SportFields";
import Layout from "./components/Layout";
import { Home } from "./components/Home";

function App() {
  return (
    <Layout>
      <Routes>
        <Route exact path="/"  element={<Home />} />
        <Route path="/sport-fields" exact element={<SportFields />} />
      </Routes>
    </Layout>
  );
}

export default App;