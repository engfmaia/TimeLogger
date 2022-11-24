import React from "react";
import ProjectCard from "../ProjectCard/ProjectCard";
import { getAll } from "../../api/projects";
import ProjectDto from "../../models/Project";
import LoadingSpinner from "../LoadingSpinner/LoadingSpinner";
import { Link } from "react-router-dom";

export default function ProjectsList() 
{
    const [loading, setLoading] = React.useState<boolean>();
    const [projects, setProjects] = React.useState<ProjectDto[]>();

    const page = 0;
    const itemsPerPage = 10;
    const orderAsceding = true;

    React.useEffect(() => {
        getAll(page, itemsPerPage, orderAsceding)
        .then(response => response.json())
        .then(response => {
            setLoading(false);
            setProjects(response);
        })
        .catch(err => console.error(err));
    }, []);

    if(loading === false && projects !== undefined) {
        return (
            <React.Fragment>
                <div className="inline-flex">
                    { projects.map(project => <ProjectCard key="{project.id}" {...project} /> ) }
                </div>
            </React.Fragment>
        )
    }
    else if(projects?.length === 0) {
        return (
            <div className="max-w-md rounded overflow-haidden mx-auto">
                <div className="px-5 py-5">
                    No project created yet. <Link to={"/project/new"}> Add a new project</Link> or <Link to={"/customer/new"}>a new customer</Link>
                </div>
            </div>
        )
    }
    else {
        return (
            <React.Fragment>
                <LoadingSpinner />
            </React.Fragment>
        )
    }
}
