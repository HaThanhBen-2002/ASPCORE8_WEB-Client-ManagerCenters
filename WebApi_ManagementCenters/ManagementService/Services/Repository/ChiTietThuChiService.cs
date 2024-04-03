using AutoMapper;
using Data.Dtos;
using Data.InterfacesData;
using Data.Models;
using ManagementService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ManagementService.Support.Support;
namespace ManagementService.Services.Repository
{
    public class ChiTietThuChiService: IChiTietThuChiService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ChiTietThuChiService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CheckId(int id)
        {
            try
            {
                if (id != 0)
                {
                    return await _unitOfWork.ChiTietThuChi.CheckId(id);
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> Create(ChiTietThuChiDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<ChiTietThuChi>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.ChiTietThuChi.Create(_mapper.Map<ChiTietThuChi>(item));
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id, string nguoiXoa)
        {
            try
            {
                if (id != 0 && nguoiXoa != null)
                {
                    return await _unitOfWork.ChiTietThuChi.Delete(id, nguoiXoa, GetCurrentDateTime());
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ICollection<ChiTietThuChiDto>> Search(ChiTietThuChiDto item)
        {
            try
            {
                if (item != null)
                {
                    return _mapper.Map<List<ChiTietThuChiDto>>(await _unitOfWork.ChiTietThuChi.Search(_mapper.Map<ChiTietThuChi>(item)));
                }
                return new List<ChiTietThuChiDto>();
            }
            catch
            {
                return new List<ChiTietThuChiDto>();
            }
        }

        public async Task<ICollection<ChiTietThuChiDto>> SearchByPhieuThuChiId(int id)
        {
            try
            {
                if (id != 0)
                {
                    return _mapper.Map<List<ChiTietThuChiDto>>(await _unitOfWork.ChiTietThuChi.SearchByPhieuThuChiId(id));
                }
                return new List<ChiTietThuChiDto>();
            }
            catch
            {
                return new List<ChiTietThuChiDto>();
            }
        }

        public async Task<bool> Update(ChiTietThuChiDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<ChiTietThuChi>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.ChiTietThuChi.Update(_mapper.Map<ChiTietThuChi>(item));
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
