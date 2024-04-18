
async function PhieuThuChi_GetAll() {
    try {
        const response = await $.ajax({
            type: "POST", url: "/PhieuThuChi/GetAll",
            headers: { "Authorization": `Bearer ${getToken()}` }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await PhieuThuChi_GetAll();
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function PhieuThuChi_GetById(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/PhieuThuChi/GetById",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await PhieuThuChi_GetById(id);
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

async function PhieuThuChi_CheckId(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/PhieuThuChi/CheckId",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await PhieuThuChi_CheckId(id);
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

async function PhieuThuChi_GetByIdTable(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/PhieuThuChi/GetByIdTable",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await PhieuThuChi_GetByIdTable(id);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function PhieuThuChi_Create(item, chiTietThuChis, thanhToan) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/PhieuThuChi/Create",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item, chiTietThuChis: chiTietThuChis, thanhToan: thanhToan },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await PhieuThuChi_Create(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function PhieuThuChi_Update(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/PhieuThuChi/Update",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await PhieuThuChi_Update(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function PhieuThuChi_UpdateThanhToan(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/PhieuThuChi/UpdateThanhToan",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await PhieuThuChi_Update(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function PhieuThuChi_Search(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/PhieuThuChi/Search",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await PhieuThuChi_Search(item);
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function PhieuThuChi_SearchTongTien(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/PhieuThuChi/SearchTongTien",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await PhieuThuChi_SearchTongTien(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function PhieuThuChi_SearchCount(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/PhieuThuChi/SearchCount",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await PhieuThuChi_SearchCount(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function PhieuThuChi_HoaDonThuThang(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/PhieuThuChi/HoaDonThuThang",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await PhieuThuChi_SearchCount(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function PhieuThuChi_HoaDonChiThang(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/PhieuThuChi/HoaDonChiThang",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await PhieuThuChi_SearchCount(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function PhieuThuChi_Delete(ids,nguoiXoa) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/PhieuThuChi/Delete",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { ids: ids, nguoiXoa: nguoiXoa },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await PhieuThuChi_Delete(ids, nguoiXoa);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}
