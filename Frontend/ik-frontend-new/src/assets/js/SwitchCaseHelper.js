
const SwitchCaseHelper ={
    approvalStatus(status){
        switch (status) {
            case 1: return "Onaylandi";
            case 2: return "Beklemede";
            case 3: return "Reddedildi";
            default: return "Hata Olustu";
        }
    },
    workingTypes(types){
        switch (types) {
            case 1: return "Bireysel"
            case 2: return "Kurumsal"
            default: return "Hata"
        }
    },
    currencyTypes(type){
        switch (type) {
            case 1: return "₺"
            case 2: return "$"
            case 3: return "€"
            case 4: return "£"
            default: return "none"
        }
    },
    filterList(status,list){
        switch (status) {
            case 1: return list.filter(x => x.approvalStatus === 1);
            case 2: return list.filter(x => x.approvalStatus === 2);
            case 3: return list.filter(x => x.approvalStatus === 3);
            default: return  list;
        }
    },
    expenseTypes(types){
        switch (types) {
            case 1: return "Yemek"
            case 2: return "Konaklama"
            case 3: return "Seyahat"
            default: return "Hata"
        }
    },
}


export default SwitchCaseHelper;