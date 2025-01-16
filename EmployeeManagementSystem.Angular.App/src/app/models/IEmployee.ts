import { IRole } from "./IRole";
import { IShift } from "./IShift";

export interface IEmployee {
     id: string;
     name: string; 
     shifts: IShift[];
     roles: IRole[];
}