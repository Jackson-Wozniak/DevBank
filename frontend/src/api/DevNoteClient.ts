
export async function fetchServerCheck(): Promise<boolean>{
    try{
        const response = await fetch("https://locahost:7113/api/healthcheck");

        return response.ok;
    }catch {
        return false;
    }
}