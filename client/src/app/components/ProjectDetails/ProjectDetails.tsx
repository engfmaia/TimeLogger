import React from "react";
import ProjectCard from "../ProjectCard/ProjectCard";
import { getSingle } from "../../api/projects";
import ProjectDto from "../../models/Project";
import LoadingSpinner from "../LoadingSpinner/LoadingSpinner";
import { useParams } from "react-router-dom";
import ProjectTimeRegistrations from "./ProjectTimeRegistrations";

type SingleProjectParams = {
    id: string;
};

export default function ProjectDetails() 
{
    const { id }= useParams<SingleProjectParams>();
    
    const [loading, setLoading] = React.useState<boolean>();
    const [project, setProject] = React.useState<ProjectDto>();
    
    React.useEffect(() => {
        getSingle(Number(id))
        .then(response => response.json())
        .then(response => {
            setLoading(false);
            setProject(response);
        })
        .catch(err => console.error(err));
    }, []);


    if(loading === false && project !== undefined) {
        return (
            <React.Fragment>
                <div className="container mx-auto">
                    <div className="inline-flex">
                        <ProjectCard key="{project.id}" {...project} />
                        <ProjectTimeRegistrations projectId={Number(id)} projectCompleted={project.completed} />
                    </div>
                </div>
            </React.Fragment>
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

