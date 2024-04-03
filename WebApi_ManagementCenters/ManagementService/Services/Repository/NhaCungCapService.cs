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
    public class NhaCungCapService : INhaCungCapService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NhaCungCapService(IUnitOfWork unitOfWork, IMapper mapper)
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
                    return await _unitOfWork.NhaCungCap.CheckId(id);
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> Create(NhaCungCapDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<NhaCungCap>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.NhaCungCap.Create(_mapper.Map<NhaCungCap>(item));
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
                    return await _unitOfWork.NhaCungCap.Delete(id, nguoiXoa, GetCurrentDateTime());
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ICollection<NhaCungCapDto>> GetAll()
        {
            try
            {
                return _mapper.Map<List<NhaCungCapDto>>(await _unitOfWork.NhaCungCap.GetAll());
            }
            catch
            {
                return new List<NhaCungCapDto>();
            }
        }

        public async Task<NhaCungCapDto> GetById(int id)
        {
            try
            {
                if (id != 0)
                {
                    return _mapper.Map<NhaCungCapDto>(await _unitOfWork.NhaCungCap.GetById(id));
                }
                return new NhaCungCapDto();
            }
            catch
            {
                return new NhaCungCapDto();
            }
        }

        public object LoadingDataTableView(NhaCungCapDto item, int skip, int take)
        {
            try
            {
                if (item != null)
                {
                    return _unitOfWork.NhaCungCap.LoadingDataTableView(_mapper.Map<NhaCungCap>(item), skip, take);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ICollection<NhaCungCapDto>> Search(NhaCungCapDto item)
        {
            try
            {
                if (item != null)
                {
                    return _mapper.Map<List<NhaCungCapDto>>(await _unitOfWork.NhaCungCap.Search(_mapper.Map<NhaCungCap>(item)));
                }
                return new List<NhaCungCapDto>();
            }
            catch
            {
                return new List<NhaCungCapDto>();
            }
        }

        public async Task<int> SearchCount(NhaCungCapDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.NhaCungCap.SearchCount(_mapper.Map<NhaCungCap>(item));
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<List<object>> SearchName(NhaCungCapDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.NhaCungCap.SearchName(_mapper.Map<NhaCungCap>(item));
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Update(NhaCungCapDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<NhaCungCap>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.NhaCungCap.Update(_mapper.Map<NhaCungCap>(item));
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
