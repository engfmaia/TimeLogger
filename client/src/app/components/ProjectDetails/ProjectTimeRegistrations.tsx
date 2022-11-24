import React from "react";
import { get } from "../../api/timeRegistrations";
import LoadingSpinner from "../LoadingSpinner/LoadingSpinner";
import TimeRegistration from "../../models/TimeRegistration";
import NewTimeRegistrationForm from "../NewTimeRegistrationForm/NewTimeRegistrationForm";

export default function ProjectTimeRegistrations(props: {projectId: number, projectCompleted: boolean}) 
{
    const [loading, setLoading] = React.useState<boolean>();
    const [timeRegistrations, setTimeRegistrations] = React.useState<TimeRegistration[]>();
    
    function retrieveTimeRegistrations() {
        React.useEffect(() => {
            get(props.projectId)
            .then(response => response.json())
            .then(response => {
                setLoading(false);
                setTimeRegistrations(response);
            })
            .catch(err => console.error(err));
        }, []);
    }
    retrieveTimeRegistrations();

    if(loading === false && timeRegistrations !== undefined) {
        return (
            <React.Fragment>
                <ol className="relative border-l border-gray-200 dark:border-gray-700"> 
                    
                    <li>
                        <div className="font-bold text-xl mb-2">Time registrations</div>
                    </li>

                    <NewTimeRegistrationForm projectId={props.projectId} projectCompleted={props.projectCompleted}/>

                    { timeRegistrations.map(timeRegistration => 
                        <li className="ml-4" key="{timeRegistration.id}">
                            <div className="absolute w-3 h-3 bg-gray-200 rounded-full mt-1.5 -left-1.5 border border-white dark:border-gray-900 dark:bg-gray-700"></div>
                            <time className="mb-1 text-sm font-normal leading-none text-gray-400 dark:text-gray-500">{timeRegistration.date}</time>
                            <p className="text-base font-normal text-gray-500 dark:text-gray-400">{timeRegistration.hours}</p>
                            <p className="text-base font-normal text-gray-500 dark:text-gray-400">{timeRegistration.date}</p>
                        </li>
                    )}
                </ol>
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