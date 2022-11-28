import React from "react";
import ProjectDto from "../../models/Project";
import { Link } from "react-router-dom";
import Moment from 'react-moment';

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
        <div className="rounded shadow-lg p-4 m-1">
            <div className="mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">
                <Link to={'/project/' + props.id}>
                    <div className="font-bold text-xl mb-2">{props.name}</div>
                </Link>
            </div>
            <p className="mb-3 font-normal text-gray-700 dark:text-gray-400">
                Deadline: <Moment format="DD/MM/YYYY" date={props.deadline} />
            </p>
            <ProjectCardTags completed={props.completed} />
        </div>
    )
}
