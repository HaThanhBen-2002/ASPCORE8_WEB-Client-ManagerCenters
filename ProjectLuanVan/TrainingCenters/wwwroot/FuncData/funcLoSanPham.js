//var LoSanPham = {
//    MaLoSanPham: null,
//    TenLoSanPham: null,
//    ThongTin: null,
//    Gia: null,
//};


async function LoSanPham_GetAll() {
    try {
        const response = await $.ajax({
            type: "POST", url: "/LoSanPham/GetAll",
            headers: { "Authorization": `Bearer ${getToken()}` }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await LoSanPham_GetAll();
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function LoSanPham_GetById(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/LoSanPham/GetById",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await LoSanPham_GetById(id);
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

async function LoSanPham_CheckId(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/LoSanPham/CheckId",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await LoSanPham_CheckId(id);
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

async function LoSanPham_GetByIdTable(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/LoSanPham/GetByIdTable",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await LoSanPham_GetByIdTable(id);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function LoSanPham_Create(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/LoSanPham/Create",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await LoSanPham_Create(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function LoSanPham_Update(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/LoSanPham/Update",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await LoSanPham_Update(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function LoSanPham_Search(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/LoSanPham/Search",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await LoSanPham_Search(item);
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function LoSanPham_SearchName(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/LoSanPham/SearchName",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await LoSanPham_SearchName(item);
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function LoSanPham_SearchCount(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/LoSanPham/SearchCount",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await LoSanPham_SearchCount(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function LoSanPham_Delete(ids,nguoiXoa) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/LoSanPham/Delete",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { ids: ids, nguoiXoa: nguoiXoa },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await LoSanPham_Delete(ids, nguoiXoa);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}
