import { ApiRequests } from "../api/Api"
const PermissionService = {
    async GetAllPermissionType (){
        return await ApiRequests.handleRequestGetAsync("/Permission/GetAllPermissionType");
    },
    async CreatePermissionRequest(data){
        return await ApiRequests.handleRequestPostAsync("/Permission/CreatePermissionRequest",data,false)
    },
    async GetAllPermissionRequest(){
        return await ApiRequests.handleRequestGetAsync("/Permission/GetAllPermissionRequest");
    },
    async DeletePermissionRequest(id){
        return await ApiRequests.handleRequestDeleteAsync(`Permission/DeletePermissionRequest?PermissionRequestId=${id}`);
    },
    async GettAllPermissionRequestManager(){
        return await ApiRequests.handleRequestGetAsync("/Permission/GetAllCompManagerPermissionRequest");
    },
    async PermissionRequestUpdate(data){
        return await ApiRequests.handleRequestPatchAsync("/Permission/PermissionRequestApprovalStatus",data);
    }
}

export default PermissionService;