const BASE_URL = "http://localhost:3001/api";

export async function getSingle(id: number) {
    return await fetch(`${BASE_URL}/projects/${id}`);
}

export async function getAll(page: number, pageSize: number, orderAsceding: boolean) {
    return await fetch(`${BASE_URL}/projects/all?page=${page}&pageSize=${pageSize}&orderAsceding=${orderAsceding}`);
}

export async function create(customerId: number, name: string, deadline: Date) {
    return await fetch(`${BASE_URL}/projects`, {
        method: 'POST',
        headers: { 
            'Content-Type': 'application/json' 
        },
        body: JSON.stringify({ "customerId": customerId, "name": name, "deadline": deadline })
    });
}