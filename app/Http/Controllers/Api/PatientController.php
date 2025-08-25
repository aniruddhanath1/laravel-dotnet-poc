<?php


/**
 * @OA\Info(
 *     version="1.0.0",
 *     title="Healthcare Portal API",
 *     description="API documentation for the Healthcare Portal (Patients, Doctors, Sessions)",
 *     @OA\Contact(
 *         email="support@healthcare-portal.com"
 *     )
 * )
 *
 * @OA\Tag(
 *     name="Patients",
 *     description="API Endpoints for Patients"
 * )
 *
 * @OA\PathItem(path="/api/v1/patients")
 */
namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\Patient;
use App\Http\Requests\StorePatientRequest;
use App\Http\Resources\PatientResource;

class PatientController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    /**
     * @OA\Get(
     *     path="/api/v1/patients",
     *     tags={"Patients"},
     *     summary="Get list of patients",
     *     @OA\Response(response=200, description="OK")
     * )
     */
    public function index()
    {
        $patients = Patient::all();
        return PatientResource::collection($patients);
    }

    /**
     * Store a newly created resource in storage.
     */
    /**
     * @OA\Post(
     *     path="/api/v1/patients",
     *     tags={"Patients"},
     *     summary="Create a new patient",
     *     @OA\RequestBody(required=true, @OA\MediaType(mediaType="application/json")),
     *     @OA\Response(response=201, description="Created")
     * )
     */
    public function store(StorePatientRequest $request)
    {
        $patient = Patient::create($request->validated());
        return new PatientResource($patient);
    }

    /**
     * Display the specified resource.
     */
    /**
     * @OA\Get(
     *     path="/api/v1/patients/{id}",
     *     tags={"Patients"},
     *     summary="Get a patient by ID",
     *     @OA\Parameter(name="id", in="path", required=true, @OA\Schema(type="integer")),
     *     @OA\Response(response=200, description="OK")
     * )
     */
    public function show(string $id)
    {
        $patient = Patient::findOrFail($id);
        return new PatientResource($patient);
    }

    /**
     * Update the specified resource in storage.
     */
    /**
     * @OA\Put(
     *     path="/api/v1/patients/{id}",
     *     tags={"Patients"},
     *     summary="Update a patient",
     *     @OA\Parameter(name="id", in="path", required=true, @OA\Schema(type="integer")),
     *     @OA\RequestBody(required=true, @OA\MediaType(mediaType="application/json")),
     *     @OA\Response(response=200, description="OK")
     * )
     */
    public function update(StorePatientRequest $request, string $id)
    {
        $patient = Patient::findOrFail($id);
        $patient->update($request->validated());
        return new PatientResource($patient);
    }

    /**
     * Remove the specified resource from storage.
     */
    /**
     * @OA\Delete(
     *     path="/api/v1/patients/{id}",
     *     tags={"Patients"},
     *     summary="Delete a patient",
     *     @OA\Parameter(name="id", in="path", required=true, @OA\Schema(type="integer")),
     *     @OA\Response(response=204, description="No Content")
     * )
     */
    public function destroy(string $id)
    {
        $patient = Patient::findOrFail($id);
        $patient->delete();
        return response()->json(null, 204);
    }
}
