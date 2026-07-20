window.loginRequest = async (username, password, institutionId) => {
    const formData = new URLSearchParams();
    formData.append("username", username);
    formData.append("password", password);
    formData.append("institutionId", institutionId);

    const response = await fetch("/Account/Login", {
        method: "POST",
        body: formData,
        credentials: "include" // important: ensures cookie gets stored
    });

    return await response.json();
};

window.logoutRequest = async () => {
    const response = await fetch("/Account/Logout", {
        method: "POST",
        credentials: "include" // ensures the auth cookie is sent and cleared
    });

    return await response.json();
};