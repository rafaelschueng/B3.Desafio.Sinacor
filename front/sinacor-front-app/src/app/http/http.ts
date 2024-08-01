export async function HttpRequest<T>(uri: URL, method: "get" | "post") {
    const response = await fetch(uri, { method: method, headers: {
        "Access-Control-Allow-Origin": "*"
    } });
    if (response.status >= 200 && response.status <= 400) {
        return await response.json() as T;
    }
    throw new Error(`HTTP fetch failed at: ${uri} with status code: ${response.status}`);
}