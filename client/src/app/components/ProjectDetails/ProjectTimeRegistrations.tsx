import React from "react";
import { get } from "../../api/timeRegistrations";
import LoadingSpinner from "../LoadingSpinner/LoadingSpinner";
import TimeRegistration from "../../models/TimeRegistration";
import NewTimeRegistrationForm from "../NewTimeRegistrationForm/NewTimeRegistrationForm";
import Moment from 'react-moment';

export default function ProjectTimeRegistrations(props: {projectId: number, projectCompleted: boolean}) 
{
    const [loading, setLoading] = React.useState<boolean>();
    const [timeRegistrations, setTimeRegistrations] = React.useState<TimeRegistration[]>();
    const [totalHours, setTotalHours] = React.useState<number>(0);
    
    function retrieveTimeRegistrations() {
        setLoading(true);
        get(props.projectId)
        .then(response => response.json())
        .then(response => {
            setLoading(false);
            setTimeRegistrations(response);
        })
        .catch(err => console.error(err));
    }
    
    React.useEffect(() => { 
        setTotalHours(timeRegistrations?.reduce( function(total, timeRegistration){ return total + timeRegistration.hours; }, 0) ?? 0);
    }, [timeRegistrations]);

    const newTimeRegistrationAdded = () => {
        retrieveTimeRegistrations();
    };
    
    React.useEffect(() => {
        retrieveTimeRegistrations();
    }, []);

    if(loading === false && timeRegistrations !== undefined) {
        return (
            <React.Fragment>
                <div className="rounded shadow-lg p-4 m-1">
                    <ol className="relative border-l border-gray-200 dark:border-gray-700"> 
                        
                        <li>
                            <div className="font-bold text-xl mb-2 p-4">Time registrations ({totalHours}h)</div>
                        </li>

                        <NewTimeRegistrationForm 
                            projectId={props.projectId} 
                            projectCompleted={props.projectCompleted}
                            newTimeRegistrationAdded={newTimeRegistrationAdded}/>

                        { timeRegistrations.map(timeRegistration => 
                            <li className="ml-4" key={timeRegistration.id}>
                                <div className="absolute w-3 h-3 bg-gray-200 rounded-full mt-1.5 -left-1.5 border border-white dark:border-gray-900 dark:bg-gray-700"></div>
                                <time className="mb-1 text-sm font-normal leading-none text-gray-400 dark:text-gray-500"><Moment format="DD/MM/YYYY" date={timeRegistration.date} /></time>
                                <p className="text-base font-normal text-gray-500 dark:text-gray-400">{timeRegistration.hours} hours</p>
                            </li>
                        )}
                    </ol>
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