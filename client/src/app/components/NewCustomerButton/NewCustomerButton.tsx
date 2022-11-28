import React from 'react';
import { Link, useLocation } from 'react-router-dom'

export default function NewCustomerButton() 
{
    const location = useLocation();
    if(location.pathname.includes("/customers/new"))
    {
    return (<></>)
    }
    else return (
        <div className="p-1.5 mx-auto">
            <Link to={'/customers/new'}>
                <button 
                    type="button" 
                    className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded-full">
                        New Customer
                </button>
            </Link>
        </div>
    )
}