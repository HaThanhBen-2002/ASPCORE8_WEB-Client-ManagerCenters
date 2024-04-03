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
    public class NhanVienService: INhanVienService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NhanVienService(IUnitOfWork unitOfWork, IMapper mapper)
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
                    return await _unitOfWork.NhanVien.CheckId(id);
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> Create(NhanVienDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<NhanVien>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.NhanVien.Create(_mapper.Map<NhanVien>(item));
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
                    return await _unitOfWork.NhanVien.Delete(id, nguoiXoa, GetCurrentDateTime());
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ICollection<NhanVienDto>> GetAll()
        {
            try
            {
                return _mapper.Map<List<NhanVienDto>>(await _unitOfWork.NhanVien.GetAll());
            }
            catch
            {
                return new List<NhanVienDto>();
            }
        }

        public async Task<NhanVienDto> GetById(int id)
        {
            try
            {
                if (id != 0)
                {
                    return _mapper.Map<NhanVienDto>(await _unitOfWork.NhanVien.GetById(id));
                }
                return new NhanVienDto();
            }
            catch
            {
                return new NhanVienDto();
            }
        }

        public object LoadingDataTableView(NhanVienDto item, int skip, int take)
        {
            try
            {
                if (item != null)
                {
                    return _unitOfWork.NhanVien.LoadingDataTableView(_mapper.Map<NhanVien>(item), skip, take);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ICollection<NhanVienDto>> Search(NhanVienDto item)
        {
            try
            {
                if (item != null)
                {
                    return _mapper.Map<List<NhanVienDto>>(await _unitOfWork.NhanVien.Search(_mapper.Map<NhanVien>(item)));
                }
                return new List<NhanVienDto>();
            }
            catch
            {
                return new List<NhanVienDto>();
            }
        }

        public async Task<int> SearchCount(NhanVienDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.NhanVien.SearchCount(_mapper.Map<NhanVien>(item));
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<List<object>> SearchName(NhanVienDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.NhanVien.SearchName(_mapper.Map<NhanVien>(item));
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Update(NhanVienDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<NhanVien>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.NhanVien.Update(_mapper.Map<NhanVien>(item));
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
