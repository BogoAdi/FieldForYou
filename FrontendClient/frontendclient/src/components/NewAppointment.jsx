
import * as React from 'react';
import { useEffect, useState } from 'react';
import axios from 'axios';
import { Button, List } from "@mui/material";
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import TextField from '@mui/material/TextField';
import { DateTimePicker } from '@mui/x-date-pickers/DateTimePicker';
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';

import { Link } from 'react-router-dom';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import { useParams } from "react-router-dom";

import { useForm } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from "yup";
import API from '../api';

const Schema = yup.object().shape({
    date: yup.date(),
    hours: yup.number(),
    sportFieldId: yup.string(),
    userId: yup.string()
})
const NewAppointment = (props) => {
    let { id } = useParams();
    const [username, setUsername] = useState([]);
    const [users, setUsers] = useState([]);
    const [finalDate, setFinalDate] = useState([]);

    const { register, handleSubmit, formState: { errors }
    } = useForm({
        resolver: yupResolver(Schema)
    });

    useEffect(() => {

        const fetchGetUser = async () => {
            const res = await API.get('Users');
            setUsers(res.data);
        }
        fetchGetUser();
    }, []);


    const handleChange = (event) => {
        setUsername(event.target.value);
    };

    const CreateAnAppointment = data => {

        const sendData = () => {
            data.date = finalDate;
            data.date.setHours(finalDate.getHours() + 3);

            data.sportFieldId = id;
            console.log(id);
            data.userId = username;

            API.post('Appointments', data)
                .then(res => {
                    alert("Appointment created");
                }).catch(err => {
                    alert("The chosen time span is not free. Please choose an appropriate slot");
                });

        };
        console.log(data);
        sendData();
    }

    return (
        <>
            <div id="Show table">
                <Link to={`/see-scheduler/${id}`}>
                    <Button >See all time slots
                    </Button>
                </Link>
            </div>
            <p></p>
            <br />
            <div id="ContainerSetting" sx={{ m: 10 }}>
                <LocalizationProvider dateAdapter={AdapterDateFns}>
                    <DateTimePicker
                        label="Date-and-Time picker"
                        value={finalDate}
                        onChange={date => {
                            setFinalDate(date);
                        }}
                        renderInput={(params) => <TextField {...params} />}
                    />
                </LocalizationProvider>
            </div><br />
            <FormControl sx={{ m: 1, minWidth: 80 }}>
                <InputLabel id="demo-simple-select-autowidth-label">User</InputLabel>
                <Select
                    labelId="demo-simple-select-autowidth-label"
                    id="demo-simple-select-autowidth"
                    value={username}
                    onChange={handleChange}
                    autoWidth
                    label="Username"
                >
                    <MenuItem value="">
                        <em>None</em>
                    </MenuItem>{
                        users.map((info, index) => (
                            <MenuItem key={index} value={info.id}>{info.username}</MenuItem>
                        ))
                    }
                </Select>
            </FormControl>

            <div>
                <form onSubmit={handleSubmit(CreateAnAppointment)}>
                    <label title="Hours" >Hours </label>
                    <br></br>
                    <input type="number" defaultValue="1" min="1" max="5"{...register('hours')} /><p></p>
                    <Button type="submit" > Create Appointment
                    </Button>
                </form>

            </div>

        </>
    )
}
export default NewAppointment;