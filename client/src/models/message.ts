import { ITabUserOptions } from "@testing-library/user-event";
import { IUser } from "./user";

export interface IMessage {
    timeStamp: string;
    sender: IUser;
    content: string;
}