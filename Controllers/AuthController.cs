﻿using Microsoft.AspNetCore.RateLimiting;
using SurveyBasket.Abstractions.Consts;

namespace SurveyBasket.Controllers;

[Route("[controller]")]
[ApiController]
[EnableRateLimiting(Limiter.IpLimit)]
public class AuthController(IAuthService authService, ILogger<AuthController> logger) : ControllerBase
{

    private readonly IAuthService _authService = authService;
    private readonly ILogger<AuthController> _logger = logger;

    [HttpPost("")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Logging with email: {email} and passwoed: {password}", request.Email, request.Password);
        var authResult = await _authService.GetTokenAsync(request.Email, request.Password, cancellationToken);

        return authResult.IsSuccess ? Ok(authResult.Value) : authResult.ToProblem();
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var authResult = await _authService.GetRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);

        return authResult.IsSuccess ? Ok(authResult.Value) : authResult.ToProblem();
    }

    [HttpPost("revoke-refresh-token")]
    public async Task<IActionResult> RevokeRefreshToken([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var result = await _authService.RevokeRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);

        return result.IsSuccess ? Ok() : result.ToProblem();
    }

    [HttpPost("register")]
    [DisableRateLimiting]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
    {
        var registerResult = await _authService.RegisterAsync(request, cancellationToken);

        return registerResult.IsSuccess ? Ok() : registerResult.ToProblem();
    }

    [HttpPost("confirm-email")]
    public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailRequest request)
    {
        var registerResult = await _authService.ConfirmEmailAsync(request);

        return registerResult.IsSuccess ? Ok() : registerResult.ToProblem();
    }

    [HttpPost("resend-confirmation-email")]
    public async Task<IActionResult> ResendConfirmationEmail([FromBody] ResendConfirmationEmailRequest request)
    {
        var resendConfirmEmail = await _authService.ResendConfirmationEmailAsync(request);

        return resendConfirmEmail.IsSuccess ? Ok() : resendConfirmEmail.ToProblem();
    }

    [HttpPost("forget-password")]
    public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordRequest request)
    {
        var registerResult = await _authService.SendResetPasswordCodeAsync(request.Email);

        return registerResult.IsSuccess ? Ok() : registerResult.ToProblem();
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
    {
        var registerResult = await _authService.ResetPasswordAsync(request);

        return registerResult.IsSuccess ? Ok() : registerResult.ToProblem();
    }
}