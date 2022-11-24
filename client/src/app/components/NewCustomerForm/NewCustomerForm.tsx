import React, { FormEvent } from "react";
import { create } from "../../api/customers";
import { ToastContainer, toast } from 'react-toastify';

export default function NewCustomerForm() 
{
    const [name, setName] = React.useState<string>();
    
    const handleSubmit = (event: FormEvent) => {
        event.preventDefault();

        if(name !== undefined){
            create(name)
            .then(response => {
                response.json()
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
            toast.success('Customer created with success!', { position: toast.POSITION.TOP_RIGHT });
        }
        else {
            toast.warning('Something went wrong. Please try again', { position: toast.POSITION.TOP_RIGHT });
        }
    };

    return (
        <React.Fragment>
            <div className="w-full max-w-sm p-4 bg-white border border-gray-200 rounded-lg shadow-md sm:p-6 md:p-8 dark:bg-gray-800 dark:border-gray-700">
                <form 
                    className="space-y-6"
                    action="#"
                    onSubmit={e => { handleSubmit(e) }}>

                    <div>
                        <label 
                            htmlFor="name"
                            className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">
                                Customer name:
                        </label>
                        <input 
                            type="name"
                            name="name"
                            id="name" 
                            className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-600 dark:border-gray-500 dark:placeholder-gray-400 dark:text-white" 
                            required
                            onChange={e => setName(e.target.value)} />
                    </div>

                    <div>
                        <button 
                            type="submit"
                            className="w-full text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                                Create
                        </button>
                    </div>

                </form>
            </div>
            <ToastContainer />
        </React.Fragment>
    )
}
