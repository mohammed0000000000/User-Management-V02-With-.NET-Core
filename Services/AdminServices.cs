using UserManagementV02.Exceptions;
using UserManagementV02.Interfaces;

namespace UserManagementV02.Services
{
	public class AdminServices : IAdminService
	{
		public void testSerivce() {
			throw new NotFoundException("Test from serivce");
		}
	}
}
