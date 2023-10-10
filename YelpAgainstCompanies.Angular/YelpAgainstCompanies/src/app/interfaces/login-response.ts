export default interface LoginResponse {
    userName: string;
    role: string;
    accessToken: string;
    refreshToken: string;
}