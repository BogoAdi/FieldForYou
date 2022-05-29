
import { useEffect, useState } from "react";
import Paginations from './Paginations';
import axios from 'axios';
import * as React from 'react';
import ItemCard from './ItemCard';
import API from '../api';

export default function SportFields() {
    /*const [productes, setProducts] = useState(
        [
            {name: "minge ronaldo", adress:"Str 1", city:"Pecica", pricePerHour:6, descripstion:"minge originala", img:"https://s13emagst.akamaized.net/products/13579/13578826/images/res_c27d9943002b98fe98cd5e275f3512ef.jpg",category:8},
            {name: "minge messi", adress:"Str 1", city:"Pecica", pricePerHour:6, descripstion:"minge originala", img:"https://s13emagst.akamaized.net/products/32158/32157174/images/res_b1bcd78ce7694225579bb5442a595677.jpg",category:8},
            {name: "minge neymar", adress:"Str 1", city:"Pecica", pricePerHour:6, descripstion:"minge originala", img:"https://s13emagst.akamaized.net/products/34532/34531719/images/res_908d4e42edf0c195a323265ff97d85d6.jpg",category:8}
        ]);
      */
    const [fields, setFields] = useState([]);
    const [loading, setLoading] = useState(false);
    const [currentPage, setCurrentPage] = useState(1);
    const [fieldsPerPage, setFieldsPerPage] = useState(4);

    useEffect(() => {
        const fetchPosts = async () => {
            setLoading(true);
            const res = await API.get('SportFields');
            setFields(res.data);
            setLoading(false);
        };

        fetchPosts();
    }, []);
    const indexOfLastFields = currentPage * fieldsPerPage;
    const indexOfFirstField = indexOfLastFields - fieldsPerPage;
    const currentFields = fields.slice(indexOfFirstField, indexOfLastFields);


    const paginate = pageNumber => setCurrentPage(pageNumber);
    const itemsPerPage = nr => setFieldsPerPage(nr);


    return (
        <div>
            <h1> SportFields</h1>
            <ItemCard sportField={currentFields} loading={loading}/>
            <Paginations
                fieldsPerPage={fieldsPerPage}
                totalFields={fields.length}
                paginate={paginate}
            />
            <></>
        </div>

    );
}


