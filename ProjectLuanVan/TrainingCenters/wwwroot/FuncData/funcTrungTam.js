//var trungTam = {
//    MaTrungTam: null,
//    TenTrungTam: null,
//    DiaChi: null,
//    Email: null,
//    MaSoThue: null,
//    SoDienThoai: null,
//    DienTich: null,
//    NganHang: null,
//    SoTaiKhoan: null,
//};

async function TrungTam_GetAll() {
    try {
        const response = await $.ajax({
            type: "POST", url: "/TrungTam/GetAll",
            headers: { "Authorization": `Bearer ${getToken()}` }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await TrungTam_GetAll();
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function TrungTam_GetById(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/TrungTam/GetById",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await TrungTam_GetById(id);
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

async function TrungTam_CheckId(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/TrungTam/CheckId",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await TrungTam_CheckId(id);
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

async function TrungTam_GetByIdTable(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/TrungTam/GetByIdTable",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await TrungTam_GetByIdTable(id);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function TrungTam_Create(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/TrungTam/Create",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await TrungTam_Create(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function TrungTam_Update(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/TrungTam/Update",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await TrungTam_Update(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function TrungTam_Search(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/TrungTam/Search",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await TrungTam_Search(item);
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function TrungTam_SearchName(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/TrungTam/SearchName",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await TrungTam_SearchName(item);
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function TrungTam_SearchCount(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/TrungTam/SearchCount",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await TrungTam_SearchCount(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function TrungTam_Delete(ids, nguoiXoa) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/TrungTam/Delete",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { ids: ids, nguoiXoa: nguoiXoa },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await TrungTam_Delete(ids, nguoiXoa);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}
