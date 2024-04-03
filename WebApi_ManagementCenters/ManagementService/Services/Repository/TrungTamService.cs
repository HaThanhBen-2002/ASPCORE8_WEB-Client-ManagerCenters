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
    public class TrungTamService : ITrungTamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TrungTamService(IUnitOfWork unitOfWork, IMapper mapper)
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
                    return await _unitOfWork.TrungTam.CheckId(id);
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> Create(TrungTamDto item)
        {

            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<TrungTam>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.TrungTam.Create(_mapper.Map<TrungTam>(item));
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
                if (id != 0&& nguoiXoa != null)
                {
                    return await _unitOfWork.TrungTam.Delete(id,nguoiXoa, GetCurrentDateTime());
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ICollection<TrungTamDto>> GetAll()
        {
            try
            {
                return _mapper.Map<List<TrungTamDto>>(await _unitOfWork.TrungTam.GetAll());
            }
            catch
            {
                return new List<TrungTamDto>();
            }
        }

        public async Task<TrungTamDto> GetById(int id)
        {
            try
            {
                if(id != 0)
                {
                    return _mapper.Map<TrungTamDto>(await _unitOfWork.TrungTam.GetById(id));
                }
                return new TrungTamDto();
            }
            catch
            {
                return new TrungTamDto();
            }
        }

        public object LoadingDataTableView(TrungTamDto item, int skip, int take)
        {
            try
            {
                if (item != null)
                {
                    var n =  _unitOfWork.TrungTam.LoadingDataTableView( _mapper.Map<TrungTam>(item), skip, take);
                    return n;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ICollection<TrungTamDto>> Search(TrungTamDto item)
        {
            try
            {
                if(item != null)
                {
                    return _mapper.Map<List<TrungTamDto>>( await _unitOfWork.TrungTam.Search(_mapper.Map<TrungTam>(item)));
                }
                return new List<TrungTamDto>();
            }
            catch
            {
                return new List<TrungTamDto>();
            }
        }

        public async Task<int> SearchCount(TrungTamDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.TrungTam.SearchCount(_mapper.Map<TrungTam>(item));
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<List<object>> SearchName(TrungTamDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.TrungTam.SearchName(_mapper.Map<TrungTam>(item));
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Update(TrungTamDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<TrungTam>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.TrungTam.Update(_mapper.Map<TrungTam>(item));
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
