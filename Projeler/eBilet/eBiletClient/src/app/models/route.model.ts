import { BusModel } from "./bus.model";

export class RouteModel{
    id: string = "";
    from: string = "";
    to: string = "";
    date: string = "";
    busId: string = "";
    bus: BusModel = new BusModel();
}