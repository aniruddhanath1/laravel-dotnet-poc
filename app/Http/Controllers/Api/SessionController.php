<?php


/**
 * @OA\Tag(
 *     name="Sessions",
 *     description="API Endpoints for Session Management"
 * )
 *
 * @OA\PathItem(path="/api/v1/sessions")
 */
namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use App\Models\Patient;
use App\Models\Doctor;

class SessionController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        //
    }

    /**
     * Store a newly created resource in storage.
     */
    /**
     * @OA\Post(
     *     path="/api/v1/sessions",
     *     tags={"Sessions"},
     *     summary="Create a new session (login)",
     *     @OA\RequestBody(required=true, @OA\MediaType(mediaType="application/json")),
     *     @OA\Response(response=201, description="Session Created")
     * )
     */
    public function store(Request $request)
    {
        $request->validate([
            'email' => 'required|email',
            'password' => 'required',
            'type' => 'required|in:doctor,patient',
        ]);

        $user = null;
        if ($request->type === 'doctor') {
            $user = Doctor::where('email', $request->email)->first();
        } else {
            $user = Patient::where('email', $request->email)->first();
        }

        // For demo, assume password is always 'password' (never do this in production)
        if ($user && $request->password === 'password') {
            $token = base64_encode(str_random(40));
            // In real app, store token/session, here just return it
            return response()->json(['token' => $token, 'user' => $user], 201);
        }

        return response()->json(['message' => 'Invalid credentials'], 401);
    }

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $id)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     */
    /**
     * @OA\Delete(
     *     path="/api/v1/sessions",
     *     tags={"Sessions"},
     *     summary="Destroy a session (logout)",
     *     @OA\Response(response=204, description="Session Destroyed")
     * )
     */
    public function destroy(Request $request)
    {
        // In real app, invalidate session/token
        return response()->json(['message' => 'Logged out'], 204);
    }
}
