import React, { FormEvent } from "react";
import { create } from "../../api/timeRegistrations";
import { ToastContainer, toast } from 'react-toastify';

interface NewTimeRegistrationProps {
    projectId: number,
    projectCompleted: boolean,
    newTimeRegistrationAdded: () => any;
}

export default function NewTimeRegistrationForm(props: NewTimeRegistrationProps) 
{
    const [hours, setHours] = React.useState<number>();
    const [date, setDate] = React.useState<Date>();

    const todayDate = new Date();
    const maxDate = new Date(todayDate.setDate(todayDate.getDate())).toISOString().split("T")[0];
    
    const handleSubmit = (event: FormEvent) => {
        event.preventDefault();
        if(hours !== undefined && date !== undefined){
            create(props.projectId, hours, date)
            .then(response => {
                response.json();
                props.newTimeRegistrationAdded();
                showToastMessage(true);
            })
            .catch(err => {
                console.error(err)
                showToastMessage(false);
            });
        }
    }

    const showToastMessage = (success: boolean) => {
        if(success) {
            toast.success('Time registration created with success!', { position: toast.POSITION.TOP_RIGHT });
        }
        else {
            toast.warning('Something went wrong. Please try again', { position: toast.POSITION.TOP_RIGHT });
        }
    };

    if(!props.projectCompleted) {
        return (
            <React.Fragment>
                <li className="ml-4">
                    <div>
                        <form 
                            className="w-full max-w-sm"
                            action="#"
                            onSubmit={e => { handleSubmit(e) }}>
                                            
                                <div className="flex items-center py-2">
                                    <input 
                                        type="number"
                                        name="hours"
                                        id="hours" 
                                        min="0.5"
                                        step="0.5"
                                        placeholder="Hours"
                                        className="m-1 bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-600 dark:border-gray-500 dark:placeholder-gray-400 dark:text-white" 
                                        required
                                        onChange={e => setHours(Number(e.target.value))} />
                                    <input 
                                        type="date"
                                        name="name"
                                        id="name" 
                                        max={maxDate}
                                        placeholder="Date"
                                        className="m-1 bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-600 dark:border-gray-500 dark:placeholder-gray-400 dark:text-white" 
                                        required
                                        onChange={e => setDate(new Date(e.target.value))} />
                                    <button 
                                        type="submit"
                                        className="m-1 w-full text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                                            Add entry
                                    </button>
                                </div>

                        </form>
                    </div>
                </li>
                <ToastContainer />
            </React.Fragment>
        )
    }
    else {
        return (<></>)
    }
}