export class ResultModel<T>{
    value?: T;
    errorMessages?: string[];
    statusCode: number = 200;
}