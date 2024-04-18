//var ChiTietThuChi = {
//    MaChiTietThuChi: null,
//    TenChiTietThuChi: null,
//    ThongTin: null,
//    Gia: null,
//};


async function ChiTietThuChi_CheckId(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/ChiTietThuChi/CheckId",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await ChiTietThuChi_CheckId(id);
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

async function ChiTietThuChi_Create(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/ChiTietThuChi/Create",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await ChiTietThuChi_Create(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function ChiTietThuChi_Update(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/ChiTietThuChi/Update",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await ChiTietThuChi_Update(item);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function ChiTietThuChi_Search(item) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/ChiTietThuChi/Search",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { item: item },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await ChiTietThuChi_Search(item);
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function ChiTietThuChi_SearchByPhieuThuChiId(id) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/ChiTietThuChi/SearchByPhieuThuChiId",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { id: id },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await ChiTietThuChi_SearchByPhieuThuChiId(item);
        }
        return response.data.$values;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

async function ChiTietThuChi_Delete(ids,nguoiXoa) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/ChiTietThuChi/Delete",
            headers: { "Authorization": `Bearer ${getToken()}` },
            data: { ids: ids, nguoiXoa: nguoiXoa },
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await ChiTietThuChi_Delete(ids, nguoiXoa);
        }
        return response.data;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}
