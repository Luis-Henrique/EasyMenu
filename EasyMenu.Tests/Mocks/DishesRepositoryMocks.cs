using EasyMenu.Application.Contracts.Response;
using EasyMenu.Application.Data.SqlServer.Repositories;
using EasyMenu.Application.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Tests.Mocks
{
    public static class DishesRepositoryMocks
    {
        public static Mock<DishesRepository> MockCreateAsync(this Mock<DishesRepository> mockRepository, DefaultResponse response)
        {
            mockRepository.Setup(x => x.CreateAsync(It.IsAny<DishesEntity>())).ReturnsAsync(response);
            return mockRepository;
        }

        public static Mock<DishesRepository> MockUpdateAsync(this Mock<DishesRepository> mockRepository, DefaultResponse response)
        {
            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<DishesEntity>())).ReturnsAsync(response);
            return mockRepository;
        }

        public static Mock<DishesRepository> MockGetByIdAsync(this Mock<DishesRepository> mockRepository, DishesEntity response)
        {
            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(response);
            return mockRepository;
        }

        public static Mock<DishesRepository> MockDeleteByIdAsync(this Mock<DishesRepository> mockRepository, DefaultResponse response)
        {
            mockRepository.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(response);
            return mockRepository;
        }
    }
}
