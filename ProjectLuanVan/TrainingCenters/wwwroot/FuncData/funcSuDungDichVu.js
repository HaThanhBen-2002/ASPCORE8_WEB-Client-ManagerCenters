//var SuDungSuDungDichVu = {
//    MaSuDungSuDungDichVu: null,
//    TenSuDungSuDungDichVu: null,
//    ThongTin: null,
//    Gia: null,
//};


async function SuDungDichVu_GetAll() {
    try {
        const response = await $.ajax({
            type: "POST", url: "/SuDungDichVu/GetAll",
            headers: { "Authorization": `Bearer ${getToken()}` }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await SuDungDichVu_GetAll();
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function SuDungDichVu_GetById(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/SuDungDichVu/GetById",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await SuDungDichVu_GetById(id);
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

async function SuDungDichVu_CheckId(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/SuDungDichVu/CheckId",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await SuDungDichVu_CheckId(id);
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

async function SuDungDichVu_GetByIdTable(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/SuDungDichVu/GetByIdTable",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await SuDungDichVu_GetByIdTable(id);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function SuDungDichVu_Create(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/SuDungDichVu/Create",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await SuDungDichVu_Create(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function SuDungDichVu_Update(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/SuDungDichVu/Update",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await SuDungDichVu_Update(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function SuDungDichVu_Search(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/SuDungDichVu/Search",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await SuDungDichVu_Search(item);
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function SuDungDichVu_SearchName(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/SuDungDichVu/SearchName",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await SuDungDichVu_SearchName(item);
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function SuDungDichVu_SearchCount(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/SuDungDichVu/SearchCount",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await SuDungDichVu_SearchCount(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function SuDungDichVu_Delete(ids, nguoiXoa) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/SuDungDichVu/Delete",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { ids: ids, nguoiXoa: nguoiXoa },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await SuDungDichVu_Delete(ids, nguoiXoa);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}
