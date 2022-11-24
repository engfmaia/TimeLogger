const BASE_URL = "http://localhost:3001/api";

export async function getSingle(id: number) {
    return await fetch(`${BASE_URL}/customers/${id}`);
}

export async function getAll() {
    return await fetch(`${BASE_URL}/customers/all`);
}

export async function create(name: string) {
    return await fetch(`${BASE_URL}/customers`, {
        method: 'POST',
        headers: { 
            'Content-Type': 'application/json' 
        },
        body: JSON.stringify({ "name": name })
    });
}