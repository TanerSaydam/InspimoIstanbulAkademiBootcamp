export class ResultModel<T>{
    value: T | null = null;
    errorMessages?: string[];
    statusCode: number = 200;
}