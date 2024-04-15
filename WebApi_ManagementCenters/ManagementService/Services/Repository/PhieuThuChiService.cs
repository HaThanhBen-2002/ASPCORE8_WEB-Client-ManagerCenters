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
    public class PhieuThuChiService: IPhieuThuChiService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PhieuThuChiService(IUnitOfWork unitOfWork, IMapper mapper)
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
                    return await _unitOfWork.PhieuThuChi.CheckId(id);
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> Create(PhieuThuChiDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<PhieuThuChi>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.PhieuThuChi.Create(_mapper.Map<PhieuThuChi>(item));
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
                    return await _unitOfWork.PhieuThuChi.Delete(id, nguoiXoa, GetCurrentDateTime());
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ICollection<PhieuThuChiDto>> GetAll()
        {
            try
            {
                return _mapper.Map<List<PhieuThuChiDto>>(await _unitOfWork.PhieuThuChi.GetAll());
            }
            catch
            {
                return new List<PhieuThuChiDto>();
            }
        }

        public async Task<PhieuThuChiDto> GetById(int id)
        {
            try
            {
                if (id != 0)
                {
                    return _mapper.Map<PhieuThuChiDto>(await _unitOfWork.PhieuThuChi.GetById(id));
                }
                return new PhieuThuChiDto();
            }
            catch
            {
                return new PhieuThuChiDto();
            }
        }

        public object LoadingDataTableView(PhieuThuChiDto item, int skip, int take)
        {
            try
            {
                if (item != null)
                {
                    return _unitOfWork.PhieuThuChi.LoadingDataTableView(_mapper.Map<PhieuThuChi>(item), skip, take);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ICollection<PhieuThuChiDto>> Search(PhieuThuChiDto item)
        {
            try
            {
                if (item != null)
                {
                    return _mapper.Map<List<PhieuThuChiDto>>(await _unitOfWork.PhieuThuChi.Search(_mapper.Map<PhieuThuChi>(item)));
                }
                return new List<PhieuThuChiDto>();
            }
            catch
            {
                return new List<PhieuThuChiDto>();
            }
        }

        public async Task<int> SearchCount(PhieuThuChiDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.PhieuThuChi.SearchCount(_mapper.Map<PhieuThuChi>(item));
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<double> SearchTongTien(PhieuThuChiDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.PhieuThuChi.SearchTongTien(_mapper.Map<PhieuThuChi>(item));
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Update(PhieuThuChiDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<PhieuThuChi>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.PhieuThuChi.Update(_mapper.Map<PhieuThuChi>(item));
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
