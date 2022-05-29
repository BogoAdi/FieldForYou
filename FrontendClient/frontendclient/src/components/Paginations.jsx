import React from 'react'

import Stack from '@mui/material/Stack';
import Pagination from '@mui/material/Pagination';

const Paginations = ({ fieldsPerPage, totalFields, paginate }) => {
    const pageNumbers = [];

    for (let i = 1; i <= Math.ceil(totalFields / fieldsPerPage); i++) {
        pageNumbers.push(i);
    }

    const afffectedByChange = (event, value) => {
        paginate(value);
    }
    return (
        <Stack spacing={1}>
            <Pagination count={pageNumbers.length} size="large" color="primary" onChange={afffectedByChange} />
        </Stack>
    )
};
export default Paginations;