//var nhaCungCap = {
//    MaNhaCungCap: null,
//    TenNhaCungCap: null,
//    GioiThieu: null,
//    Email: null,
//    SoDienThoai: null,
//    NganHang: null,
//    SoTaiKhoan: null,
//    MaSoThue: null,
//    MaTrungTam: null
//};


async function NhaCungCap_GetAll() {
    try {
        const response = await $.ajax({
            type: "POST", url: "/NhaCungCap/GetAll",
            headers: { "Authorization": `Bearer ${getToken()}` }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await NhaCungCap_GetAll();
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function NhaCungCap_GetById(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/NhaCungCap/GetById",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await NhaCungCap_GetById(id);
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

async function NhaCungCap_CheckId(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/NhaCungCap/CheckId",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await NhaCungCap_CheckId(id);
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

async function NhaCungCap_GetByIdTable(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/NhaCungCap/GetByIdTable",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await NhaCungCap_GetByIdTable(id);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function NhaCungCap_Create(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/NhaCungCap/Create",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await NhaCungCap_Create(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function NhaCungCap_Update(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/NhaCungCap/Update",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await NhaCungCap_Update(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function NhaCungCap_Search(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/NhaCungCap/Search",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await NhaCungCap_Search(item);
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function NhaCungCap_SearchName(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/NhaCungCap/SearchName",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await NhaCungCap_SearchName(item);
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function NhaCungCap_SearchCount(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/NhaCungCap/SearchCount",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await NhaCungCap_SearchCount(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function NhaCungCap_Delete(ids,nguoiXoa) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/NhaCungCap/Delete",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { ids: ids, nguoiXoa: nguoiXoa },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await NhaCungCap_Delete(ids, nguoiXoa);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}
