//let message = {
//    To: emails,
//    Subject: subject,
//    Content: contentEmail,
//};
async function SendEmailText(message) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/SendEmail/SendEmailText",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { message: message }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await SendEmailText(message);
        }
        else if (response.isSuccess === true) {
            return response.data;
        }
        return null;
    } catch (error) {
        console.log("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function SendEmailKyThuat(message) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/SendEmail/SendEmailKyThuat",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { message: message }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await SendEmailKyThuat(message);
        }
        else if (response.isSuccess === true) {
            return response.data;
        }
        return null;
    } catch (error) {
        console.log("Lỗi Try_Ca:", error);
        throw error;
    }
}

