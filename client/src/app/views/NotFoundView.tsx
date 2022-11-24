import React from "react";
import { Link } from "react-router-dom";

export default function NotFoundView() 
{
    return (
        <div className="max-w-md rounded overflow-haidden mx-auto">
            <div className="px-5 py-5">
                Page not found. <Link to={"/"}> Click here to go back to the Homepage</Link>
            </div>
        </div>
    )
}
