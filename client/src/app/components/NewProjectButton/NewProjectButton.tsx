import React from 'react';
import { Link, useLocation } from 'react-router-dom'

export default function NewProjectButton() 
{
    const location = useLocation();
    if(location.pathname.includes("/project/new"))
    {
    return (<></>)
    }
    else return (
        <div className="p-1.5 mx-auto">
            <Link to={'/project/new'}>
                <button 
                    type="button" 
                    className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded-full">
                        New Project
                    </button>
            </Link>
        </div>
    )
}