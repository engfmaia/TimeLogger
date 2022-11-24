import React from "react";
import ProjectDto from "../../models/Project";
import { Link } from "react-router-dom";

interface ProjectCardTagsProps {
    completed: boolean
} 

function ProjectCardTags(props: ProjectCardTagsProps)
{
    if(props.completed) {
        return(<span className="inline-block bg-green-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2 mb-2">#completed</span>)
    }
    else {
        return(<span className="inline-block bg-red-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2 mb-2">#on-going</span>)
    }
}

export default function ProjectCard(props: ProjectDto) {
    return (
        <div className="max-w-sm rounded overflow-hidden shadow-lg m-1">
            <div className="px-6 py-4">
                <Link to={'/project/' + props.id}>
                    <div className="font-bold text-xl mb-2">{props.name}</div>
                </Link>
            </div>
            <div className="px-6 pt-4 pb-2">
                <ProjectCardTags completed={props.completed} />
            </div>
        </div>
    )
}
