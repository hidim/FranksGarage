export default interface IVehicleProxyModel {
    id: number | any,
    vehicleMake: string,
    vehicleModel: string,
    vehicleInsertedDate: Date,
    vehicleModelYear: number,
    vehiclePrice: number,
    vehicleIsLicensed: boolean,
    carLocationName: string,
    warehouseName: string,
    warehouseLocationLat: string,
    warehouseLocationLong: string
}