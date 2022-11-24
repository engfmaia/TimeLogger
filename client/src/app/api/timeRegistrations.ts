const BASE_URL = "http://localhost:3001/api";

export async function get(projectId: number) {
    return await fetch(`${BASE_URL}/timeregistrations/${projectId}`);
}

export async function create(projectId: number, hours: number, date: Date) {
    return await fetch(`${BASE_URL}/timeregistrations`, {
        method: 'POST',
        headers: { 
            'Content-Type': 'application/json' 
        },
        body: JSON.stringify({ "projectId": projectId, "hours": hours, "date": date })
    });
}