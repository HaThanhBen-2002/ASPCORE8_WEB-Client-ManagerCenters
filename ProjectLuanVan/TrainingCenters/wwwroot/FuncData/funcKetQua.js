//var KetQua = {
//    MaKetQua: null,
//    TenKetQua: null,
//    ThongTin: null,
//    Gia: null,
//};

async function KetQua_GetAll() {
    try {
        const response = await $.ajax({
            type: "POST", url: "/KetQua/GetAll",
            headers: { "Authorization": `Bearer ${getToken()}` }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await KetQua_GetAll();
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function KetQua_GetById(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/KetQua/GetById",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await KetQua_GetById(id);
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

async function KetQua_CheckId(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/KetQua/CheckId",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await KetQua_CheckId(id);
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

async function KetQua_GetByIdTable(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/KetQua/GetByIdTable",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await KetQua_GetByIdTable(id);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function KetQua_Create(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/KetQua/Create",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await KetQua_Create(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function KetQua_Update(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/KetQua/Update",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await KetQua_Update(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function KetQua_Search(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/KetQua/Search",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await KetQua_Search(item);
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function KetQua_SearchName(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/KetQua/SearchName",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await KetQua_SearchName(item);
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function KetQua_SearchCount(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/KetQua/SearchCount",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await KetQua_SearchCount(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function KetQua_Delete(ids,nguoiXoa) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/KetQua/Delete",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { ids: ids, nguoiXoa: nguoiXoa },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await KetQua_Delete(ids, nguoiXoa);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}
