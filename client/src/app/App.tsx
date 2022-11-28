import * as React from "react";
import { BrowserRouter, Routes, Route, Link } from "react-router-dom";
import ProjectsView from "./views/ProjectsView";
import SingleProjectView from "./views/SingleProjectView";
import NewProjectView from "./views/NewProjectView";
import NewCustomerView from "./views/NewCustomerView";
import NotFoundView from "./views/NotFoundView";
import "./style.css";
import "react-toastify/dist/ReactToastify.css";
import NewCustomerButton from "./components/NewCustomerButton/NewCustomerButton";
import NewProjectButton from "./components/NewProjectButton/NewProjectButton";

export default function App() {
    return (
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
                        <NewCustomerButton />
                        <NewProjectButton />
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
    );
}