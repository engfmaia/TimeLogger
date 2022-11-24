import * as React from "react";
import { BrowserRouter, Routes, Route, Link } from "react-router-dom";
import ProjectsView from "./views/ProjectsView";
import SingleProjectView from "./views/SingleProjectView";
import NewProjectView from "./views/NewProjectView";
import NewCustomerView from "./views/NewCustomerView";
import NotFoundView from "./views/NotFoundView";
import "./style.css";
import "react-toastify/dist/ReactToastify.css";

export default function App() {
    return (
        <>
            <BrowserRouter>
                <header className="bg-blue-500 text-white font-bold py-2 px-4">
                    <div className="container mx-auto">
                        <Link className="navbar-brand" to={"/"}>
                            Timelogger
                        </Link>
                    </div>
                </header>

                <main>
                    <div className="container mx-auto">
                        <div className="inline-flex">
                            <div className="p-1.5 mx-auto">
                                <Link to={'/customers/new'}>
                                    <button 
                                        type="button" 
                                        className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded-full">
                                            New Customer
                                        </button>
                                </Link>
                            </div>
                            <div className="p-1.5 mx-auto">
                                <Link to={'/project/new'}>
                                    <button 
                                        type="button" 
                                        className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded-full">
                                            New Project
                                        </button>
                                </Link>
                            </div>
                        </div>
                        <Routes>
                            <Route path="/" element={<ProjectsView />} />
                            <Route path="/project/:id" element={<SingleProjectView />} />
                            <Route path="/project/new" element={<NewProjectView />} />
                            <Route path="/customers/new" element={<NewCustomerView />} />
                            <Route path='*' element={<NotFoundView />} />
                        </Routes>
                    </div>
                </main>

            </BrowserRouter>
        </>
    );
}