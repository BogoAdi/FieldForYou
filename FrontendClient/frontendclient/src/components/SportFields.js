
import { useEffect, useState } from "react";
import * as React from 'react';
import ItemCard from './ItemCard';

export default function SportFields(){
const [productes, setProducts] = useState(
    [
        {name: "minge ronaldo", adress:"Str 1", city:"Pecica", pricePerHour:6, descripstion:"minge originala", img:"https://s13emagst.akamaized.net/products/13579/13578826/images/res_c27d9943002b98fe98cd5e275f3512ef.jpg",category:8},
        {name: "minge messi", adress:"Str 1", city:"Pecica", pricePerHour:6, descripstion:"minge originala", img:"https://s13emagst.akamaized.net/products/32158/32157174/images/res_b1bcd78ce7694225579bb5442a595677.jpg",category:8},
        {name: "minge neymar", adress:"Str 1", city:"Pecica", pricePerHour:6, descripstion:"minge originala", img:"https://s13emagst.akamaized.net/products/34532/34531719/images/res_908d4e42edf0c195a323265ff97d85d6.jpg",category:8}
    ]);
    
   return (
        <div>
            <h1> SportFields</h1>
            <ItemCard sportField={productes}/>
            <></>
        </div>
        
    );
}